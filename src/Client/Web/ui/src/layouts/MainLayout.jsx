import React, { useState } from 'react'
import { Box, createTheme, Stack, ThemeProvider } from "@mui/material";
import Sidebar from '../components/Sidebar';
import Navbar from "../components/Navbar";
import Add from "../components/Add";
import JWTHelper from "../utils/jwtHelper";

const MainLayout = ({children}) => {
  const [mode, setMode] = useState("light");
  const {user} = JWTHelper.getUserDetails();
  

  const darkTheme = createTheme({
    palette: {
    mode: mode,
    },
  });


  return (
    <ThemeProvider theme={darkTheme}>
        <Box bgcolor={"background.default"} color={"text.primary"}>
            <Navbar user={user} />
            <Stack direction="row" alignItems={"space-between"} sx={{height:"calc(100vh - 65px)"}}>
                <Sidebar user={user} setMode={setMode} mode={mode}/>
                {children}
            </Stack>
            {user != null ? <Add /> : <></>}
        </Box>
    </ThemeProvider>
  )
}

export default MainLayout;