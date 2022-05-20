import React,{ useState } from 'react'
import Sidebar from "../components/Sidebar";
import Feed from "../components/Feed";
import { Box, createTheme, Stack, ThemeProvider } from "@mui/material";
import Navbar from "../components/Navbar";
import Add from "../components/Add";

const Home = () => {
    const [mode, setMode] = useState("light");

    const darkTheme = createTheme({
        palette: {
        mode: mode,
        },
    });
    return (
        <ThemeProvider theme={darkTheme}>
            <Box bgcolor={"background.default"} color={"text.primary"}>
                <Navbar />
                <Stack direction="row" spacing={2} justifyContent="space-between">
                <Sidebar setMode={setMode} mode={mode}/>
                    <Feed />
                </Stack>
                <Add />
            </Box>
      </ThemeProvider>
    );
}

export default Home;