import React, { useEffect } from 'react'
import {
    Box, Stack, Grid, Avatar, FormControl,
    FormHelperText,
    Button,
    InputLabel,
    OutlinedInput,
    Typography,
    useMediaQuery
} from "@mui/material";
import { useTheme } from '@mui/material/styles';

import { toast } from "react-toastify";
import { useSelector, useDispatch } from "react-redux";

// project imports
import useScriptRef from '../hooks/useScriptRef';
import AnimateButton from '../components/AnimateButton';
import {updateUser, getUserById} from "../redux/features/userSlice";
// third party
import * as Yup from 'yup';
import { Formik } from 'formik';

import JWTHelper from '../utils/jwtHelper';

const Profile = () => {
    const { user } = JWTHelper.getUserDetails();
    const theme = useTheme();
    const scriptedRef = useScriptRef();
    const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));
    const {error, appUser} = useSelector((state) => ({...state.user}));
    const dispatch = useDispatch();

    const initialValues = {
        email: (appUser != null ? appUser.email : user.email),
        name: (appUser != null ? appUser.name : user.name),
        surname: (appUser != null ? appUser.surname : user.surname),
        submit: null
    };
    const validationSchema = Yup.object().shape({
        email: Yup.string().email("Must be a valid email").max(255).required("Email is required"),
        name: Yup.string().max(75).required("Name is required"),
        surname: Yup.string().max(75).required("Surname is required"),
    });

    useEffect(()=>{
            error && toast.error(error);
            dispatch(getUserById({id:user.id}))
    }, [error,dispatch]);

    const onSubmitForm = async (values, { setErrors, setStatus, setSubmitting }) => {
        try {
            if (scriptedRef.current) {
                setStatus({ success: true });
                setSubmitting(false);
            }
            if (values.email && values.name && values.surname) {
                const formValue = {
                    email: values.email,
                    name: values.name,
                    surname: values.surname,
                    id: user.id
                };
                const parameters = {
                    formValue,
                    toast
                }
                dispatch(updateUser(parameters));
            }
        } catch (err) {
            console.error(err);
            if (scriptedRef.current) {
                setStatus({ success: false });
                setErrors({ submit: err.message });
                setSubmitting(false);
            }
        }
    };
    return (
        <Grid direction={"column"} alignItems={"center"} justifyContent={"flex-start"} container spacing={matchDownSM ? 0 : 2} columns={{ xs: 4, sm: 8, md: 12, height: "100vh"}}>
                        <Stack direction={"column"} alignItems={"center"} justifyContent={"flex-start"} color={"text.primary"} sx={{ mt: 5, ml:2, mr:2 }}>
                            <Typography
                                variant="caption"
                                fontSize="32px"
                                fontWeight={"bold"}
                                gutterBottom
                                textAlign={matchDownSM ? 'center' : 'inherit'}
                            >
                                User Details
                            </Typography>
                            <Avatar sx={{ bgcolor: "text.primary", mb: 2, height: 150, width: 150 }} aria-label="recipe">
                                {`${user ? user.name.toUpperCase().at(0) : "M"}`}
                            </Avatar>
                            <Formik
                                enableReinitialize
                                initialValues={initialValues}
                                validationSchema={validationSchema}
                                onSubmit={onSubmitForm}
                            >
                                {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values }) => (
                                    <form noValidate onSubmit={handleSubmit}>
                                        <FormControl sx={{ mb: 1, }} fullWidth error={Boolean(touched.email && errors.email)}>
                                            <InputLabel htmlFor="outlined-adornment-email-login">Email Address</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-email-login"
                                                type="email"
                                                value={values.email}
                                                name="email"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                label="Email Address"
                                                inputProps={{}}
                                            />
                                            {touched.email && errors.email && (
                                                <FormHelperText error id="standard-weight-helper-text-email-login">
                                                    {errors.email}
                                                </FormHelperText>
                                            )}
                                        </FormControl>

                                        <FormControl sx={{ mb: 1, }} fullWidth error={Boolean(touched.name && errors.name)}>
                                            <InputLabel htmlFor="outlined-adornment-name-login">Name</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-name-login"
                                                type="text"
                                                value={values.name}
                                                name="name"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                label="Name"
                                                inputProps={{}}
                                            />
                                            {touched.name && errors.name && (
                                                <FormHelperText error id="standard-weight-helper-text-name-login">
                                                    {errors.name}
                                                </FormHelperText>
                                            )}
                                        </FormControl>

                                        <FormControl fullWidth error={Boolean(touched.surname && errors.surname)}>
                                            <InputLabel htmlFor="outlined-adornment-surname-login">Surname</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-email-login"
                                                type="text"
                                                value={values.surname}
                                                name="surname"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                label="Surname"
                                                inputProps={{}}
                                            />
                                            {touched.surname && errors.surname && (
                                                <FormHelperText error id="standard-weight-helper-text-surname-login">
                                                    {errors.surname}
                                                </FormHelperText>
                                            )}
                                        </FormControl>
                                        
                                        {errors.submit && (
                                            <Box sx={{ mt: 3 }}>
                                                <FormHelperText error>{errors.submit}</FormHelperText>
                                            </Box>
                                        )}
                                        <Box sx={{ mt: 2 }}>
                                            <AnimateButton>
                                                <Button
                                                    disableElevation
                                                    disabled={isSubmitting}
                                                    fullWidth
                                                    size="large"
                                                    type="submit"
                                                    variant="contained"
                                                    color="secondary"
                                                >
                                                    Update User
                                                </Button>
                                            </AnimateButton>
                                        </Box>
                                    </form>
                                )}
                            </Formik>
                        </Stack>
        </Grid>
    )
}

export default Profile;