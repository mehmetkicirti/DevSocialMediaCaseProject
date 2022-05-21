import React from 'react'
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
    Typography,
    useMediaQuery
} from '@mui/material';

// third party
import * as Yup from 'yup';
import { Formik } from 'formik';

// project imports
import useScriptRef from '../hooks/useScriptRef';
import AnimateButton from '../components/AnimateButton';
import { strengthColor, strengthIndicator } from '../utils/password-strength';
import { register } from '../redux/features/authSlice';

// assets
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';

const AuthRegister = ({ ...others }) => {
  
    const theme = useTheme();
    const scriptedRef = useScriptRef();
    const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const {error} = useSelector((...state) => ({...state.auth}));
    const [showPassword, setShowPassword] = useState(false);
    const [checked, setChecked] = useState(true);

    const [strength, setStrength] = useState(0);
    const [level, setLevel] = useState();
  
  
    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };

    const changePassword = (value) => {
        const temp = strengthIndicator(value);
        setStrength(temp);
        setLevel(strengthColor(temp));
    };

    useEffect(()=>{
        error && toast.error(error);
    }, [error]);

    const checkValuesEmpty = (formValues) => {
        Object.values(formValues).forEach((value)=>{
            if(!value && value == ""){
                return true;
            }
        });
        return false;
    }

  return (
        <>
            <Grid container direction="column" justifyContent="center" spacing={2}>
                <Grid item xs={12}>
                    <Formik
                        initialValues={{
                            email: '',
                            password: '',
                            name:'',
                            surname:'',
                            submit: null
                        }}
                        validationSchema={Yup.object().shape({
                            name: Yup.string().max(50).required('Name is required'),
                            surname: Yup.string().max(50).required('Surname is required'),
                            email: Yup.string().email('Must be a valid email').max(255).required('Email is required'),
                            password: Yup.string().min(8).max(16).required('Password is required')
                        })}
                        onSubmit={async (values, { setErrors, setStatus, setSubmitting }) => {
                            try {
                                if (scriptedRef.current) {
                                    setStatus({ success: true });
                                    setSubmitting(false);
                                }
                                if(!checkValuesEmpty(values)){
                                    const formValues = (({name,surname,password,email})=>({name,surname,password,email}))(values);
                                    dispatch(register({formValues,navigate, toast}));
                                }
                            } catch (err) {
                                console.error(err);
                                if (scriptedRef.current) {
                                    setStatus({ success: false });
                                    setErrors({ submit: err.message });
                                    setSubmitting(false);
                                }
                            }
                        }}
                    >
                    {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values }) => (
                        <form noValidate onSubmit={handleSubmit} {...others}>
                            <Grid container spacing={matchDownSM ? 0 : 2} sx={{mb:1}}>
                                <Grid item xs={12} sm={6}>                                   
                                    <FormControl error={Boolean(touched.name && errors.name)}>
                                        <InputLabel htmlFor="outlined-adornment-name-register">Name</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-name-register"
                                                type="text"
                                                value={values.name}
                                                name="name"
                                                label="Name"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                inputProps={{}}
                                            />
                                        {touched.name && errors.name && (
                                            <FormHelperText error id="standard-weight-helper-text-name-register">
                                                {errors.name}
                                            </FormHelperText>
                                        )}
                                    </FormControl>
                                </Grid>
                                <Grid item xs={12} sm={6}>
                                    <FormControl error={Boolean(touched.surname && errors.surname)}>
                                        <InputLabel htmlFor="outlined-adornment-surname-register">Surname</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-surname-register"
                                                type="text"
                                                value={values.surname}
                                                name="surname"
                                                label="Surname"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                inputProps={{}}
                                            />
                                        {touched.surname && errors.surname && (
                                            <FormHelperText error id="standard-weight-helper-text-surname-register">
                                                {errors.surname}
                                            </FormHelperText>
                                        )}
                                    </FormControl>
                                </Grid>
                            </Grid>
                            <FormControl fullWidth error={Boolean(touched.email && errors.email)} sx={{...theme.typography, mb:1}}>
                            <InputLabel htmlFor="outlined-adornment-email-register">Email Address</InputLabel>
                                <OutlinedInput
                                    id="outlined-adornment-email-register"
                                    type="email"
                                    value={values.email}
                                    name="email"
                                    label="Email Address"
                                    onBlur={handleBlur}
                                    onChange={handleChange}
                                    inputProps={{}}
                                />
                            {touched.email && errors.email && (
                                <FormHelperText error id="standard-weight-helper-text--register">
                                    {errors.email}
                                </FormHelperText>
                            )}
                            </FormControl>
                            <FormControl
                            fullWidth
                            error={Boolean(touched.password && errors.password)}
                            sx={{ ...theme.typography }}
                        >
                            <InputLabel htmlFor="outlined-adornment-password-register">Password</InputLabel>
                            <OutlinedInput
                                id="outlined-adornment-password-register"
                                type={showPassword ? 'text' : 'password'}
                                value={values.password}
                                name="password"
                                label="Password"
                                onBlur={handleBlur}
                                onChange={(e) => {
                                    handleChange(e);
                                    changePassword(e.target.value);
                                }}
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
                                inputProps={{}}
                            />
                            {touched.password && errors.password && (
                                <FormHelperText error id="standard-weight-helper-text-password-register">
                                    {errors.password}
                                </FormHelperText>
                            )}
                            </FormControl>
                            {strength !== 0 && (
                                <FormControl fullWidth>
                                    <Box sx={{ mb: 2 }}>
                                        <Grid container spacing={2} alignItems="center">
                                            <Grid item>
                                                <Box
                                                    style={{ backgroundColor: level?.color }}
                                                    sx={{ width: 85, height: 8, borderRadius: '7px' }}
                                                />
                                            </Grid>
                                            <Grid item>
                                                <Typography variant="subtitle1" fontSize="0.75rem">
                                                    {level?.label}
                                                </Typography>
                                            </Grid>
                                        </Grid>
                                    </Box>
                                </FormControl>
                            )}
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
                                        Sign up
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

export default AuthRegister;