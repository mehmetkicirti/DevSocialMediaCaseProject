import React from 'react';
import { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from "react-router-dom";
import {toast} from "react-toastify";
// material-ui
import { useTheme } from '@mui/material/styles';
import {
    Box,
    Button,
    FormControl,
    FormHelperText,
    Grid,
    IconButton,
    InputAdornment,
    InputLabel,
    OutlinedInput,
    useMediaQuery
} from '@mui/material';

// third party
import * as Yup from 'yup';
import { Formik } from 'formik';


// project imports
import useScriptRef from '../hooks/useScriptRef';
import AnimateButton from '../components/AnimateButton';

// assets
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';

import {login} from "../redux/features/authSlice";

const AuthLogin = ({...others}) => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const theme = useTheme();
    const {error} = useSelector((state) => ({...state.auth}));
    const scriptedRef = useScriptRef();
    const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));

    const [showPassword, setShowPassword] = useState(false);

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };
    
    const initialValues = {
        email: 'nttdata@test.com',
        password:'Mehmet_1234',
        submit:null
    };

    useEffect(()=>{
        if(error){
            toast.error(error);
            
        }
    }, [error]);


    const validationSchema = Yup.object().shape({
        email:Yup.string().email("Must be a valid email").max(255).required("Email is required"),
        password: Yup.string().max(16).required("Password is required")
    });
    const onSubmitForm = async (values, { setErrors, setStatus, setSubmitting }) => {
        try {
            if (scriptedRef.current) {
                setStatus({ success: true });
                setSubmitting(false);
            }
            if(values.email && values.password){
                const formValues = {
                    email: values.email,
                    password: values.password
                };
                const parameters = {
                    formValues,
                    navigate,
                    toast
                }

                dispatch(login(parameters));
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

    const inputFormStyle = {
        marginTop: 1,
            marginBottom: 1,
            '& > label': {
                top: 23,
                left: 0,
                color: theme.grey500,
                '&[data-shrink="false"]': {
                    top: 5
                }
            },
            '& > div > input': {
                padding: '30.5px 14px 11.5px !important'
            },
            '& legend': {
                display: 'none'
            },
            '& fieldset': {
                top: 0
            }
    };
    return (
        <>
            <Grid container direction="column" justifyContent={"center"} spacing={2}>
                <Grid item xs={12}>
                    <Formik
                        initialValues={initialValues}
                        validationSchema={validationSchema}
                        onSubmit={onSubmitForm}
                    >
                    {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values }) => (
                        <form noValidate onSubmit={handleSubmit} {...others}>
                            <FormControl fullWidth error={Boolean(touched.email && errors.email)} sx={inputFormStyle}>
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
                            <FormControl fullWidth
                                error={Boolean(touched.password && errors.password)} sx={inputFormStyle}>
                                <InputLabel htmlFor="outlined-adornment-password-login">Password</InputLabel>
                                <OutlinedInput
                                id="outlined-adornment-password-login"
                                type={showPassword ? 'text' : 'password'}
                                value={values.password}
                                name="password"
                                onBlur={handleBlur}
                                onChange={handleChange}
                                endAdornment={
                                    <InputAdornment position="end">
                                        <IconButton
                                            aria-label="toggle password visibility"
                                            onClick={handleClickShowPassword}
                                            onMouseDown={handleMouseDownPassword}
                                            edge="end"
                                            size="large"
                                        >
                                            {showPassword ? <Visibility /> : <VisibilityOff />}
                                        </IconButton>
                                    </InputAdornment>
                                }
                                label="Password"
                                inputProps={{}}
                                />
                                {touched.password && errors.password && (
                                    <FormHelperText error id="standard-weight-helper-text-password-login">
                                        {errors.password}
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
                                        Sign in
                                    </Button>
                                </AnimateButton>
                            </Box>              
                        </form>
                    )}    
                    </Formik>
                </Grid>
            </Grid>
        </>
    );
}

export default AuthLogin;