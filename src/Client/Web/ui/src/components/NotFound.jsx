import React from 'react'
import { Box, Grid, Button, ButtonGroup } from "@mui/material";
import {Link} from "react-router-dom";
import ConstructionIcon from '@mui/icons-material/Construction';
const NotFound = ({errorValue, isAuthenticated}) => {
  return (
    <Grid container direction="column" justifyContent={"center"} spacing={2} flex alignItems={"center"} sx={{height:"calc(100vh - 136px)"}}>
        <Grid item justifyContent={"center"} xs={12}>
            <Box
                sx={{
                    width: 250,
                    height: "100%",
                    display: "flex",
                    flexDirection:"column",
                    justifyContent:"center",
                    alignItems:"center"
                }}
            >
                <ConstructionIcon sx={{                    color: 'primary.dark',
                    '&:hover': {
                    color: 'primary.main',
                    opacity: [0.9, 0.8, 0.7],
                    },}} fontSize='large'/>
                {errorValue}
                {isAuthenticated ? 
                <ButtonGroup sx={{mt:1}} variant="contained">
                    <Button component={Link} sx={{ display: { xs: "block" } }} to={"/register"} variant="contained" color={"success"}>Sign Up</Button>
                    <Button component={Link} sx={{ display: { xs: "block" } }} to={"/login"} variant="contained" color={"secondary"}>Sign In</Button>
                </ButtonGroup> : <></>}
            </Box>
            
        </Grid>
        
    </Grid>
  )
}

export default NotFound;