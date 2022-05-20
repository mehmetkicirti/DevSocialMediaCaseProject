import React from 'react'
import { Link } from 'react-router-dom';

// material-ui
import { useTheme } from '@mui/material/styles';
import { Divider, Grid, Stack, Typography, useMediaQuery } from '@mui/material';
import ConnectWithoutContactIcon from '@mui/icons-material/ConnectWithoutContact';

// project imports
import AuthWrapperStyle from '../wrappers/AuthWrapperStyle';
import AuthCardWrapper from '../wrappers/AuthCardWrapper';
import AuthRegister from '../components/AuthRegister';


const Register = () => {
    const theme = useTheme();
    const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));

    return (
        <AuthWrapperStyle>
            <Grid container direction="column" justifyContent={"center"} sx={{minHeight:"100vh"}}>
                <Grid item xs={12}>
                <Grid container justifyContent={"center"} alignItems={"center"} sx={{minHeight:"calc(100vh-68px)"}}>
                        <Grid item sx={{m:{xs:1, sm:3}, mb:0}}>
                        <AuthCardWrapper>
                            <Grid container spacing={2} alignItems={"center"} justifyContent={"center"}>
                                <Grid item>
                                        <Link to="/">
                                            <ConnectWithoutContactIcon fontSize='large'/>
                                        </Link>
                                </Grid>
                                <Grid item xs={12}>
                                        <Grid
                                            container
                                            direction={matchDownSM ? 'column-reverse' : 'row'}
                                            alignItems="center"
                                            justifyContent="center"
                                        >
                                            <Grid item>
                                                <Stack alignItems="center" justifyContent="center" spacing={1}>
                                                    <Typography
                                                        variant="caption"
                                                        fontSize="32px"
                                                        fontWeight={"bold"}
                                                        gutterBottom
                                                        color={theme.palette.secondary.dark}
                                                        textAlign={matchDownSM ? 'center' : 'inherit'}
                                                    >
                                                        Sign Up
                                                    </Typography>
                                                </Stack>
                                            </Grid>
                                        </Grid>
                                </Grid>
                                <Grid item xs={12}>
                                        <AuthRegister />
                                </Grid>
                                <Grid item xs={12}>
                                        <Divider />
                                </Grid>
                                <Grid item xs={12}>
                                        <Grid item container direction="column" alignItems="center" xs={12}>
                                            <Typography
                                                component={Link}
                                                to="/login"
                                                variant="subtitle2"
                                                sx={{ textDecoration: 'none' }}
                                            >
                                                Already have an account?
                                            </Typography>
                                        </Grid>
                                </Grid>
                            </Grid>
                        </AuthCardWrapper>
                        </Grid>
                    </Grid>
                </Grid>
            </Grid>
        </AuthWrapperStyle>
    )
}

export default Register;