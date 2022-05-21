import { Box, Stack, Skeleton, Grid, useMediaQuery, TextField } from "@mui/material";
import { useTheme } from '@mui/material/styles';
import { useDispatch, useSelector } from 'react-redux';
import {toast} from "react-toastify";
import React, { useState, useEffect } from "react";
import Post from "./Post";

import {getPosts} from "../redux/features/postSlice";
import NotFound from "./NotFound";


const Feed = () => {
  const theme = useTheme();
  const dispatch = useDispatch();
  const [searchValue, setSearchValue] = useState("");
  const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));
  let {loading, list, error} = useSelector((state) => ({...state.post}))
  const [filteredResults, setFilteredResults] = useState([]);
  useEffect(() => {
    error && toast.error(error);
    dispatch(getPosts({}));
  }, [dispatch, error]);
  
  
  const onSearch = (searchValue) => {
    setSearchValue(searchValue);
    if (searchValue !== '') {
      const filteredData = list.filter((item) => {
          return Object.values(item).join('').toLowerCase().includes(searchValue.toLowerCase())
      })
      setFilteredResults(filteredData);
    }
    else{
      setFilteredResults(list);
    }
  }

  const setUIPosts = () => {
    if(searchValue.length >= 1 && filteredResults && filteredResults.length > 0) {
      return (
        filteredResults.map((postItem, index) => (
          <Grid item xs={12} sm={4} md={4} key={index}>
            <Post postItem ={postItem}/>
          </Grid>
        ))
      );
    }else if(searchValue.length < 1 && list && list.length > 0){
      return (
        list.map((postItem, index) => (
          <Grid item xs={12} sm={4} md={4} key={index}>
            <Post postItem ={postItem}/>
          </Grid>
        ))
      );
    }else{
      return (
        <NotFound errorValue={"Post Not Found"}/>
      );
    }
  };

  return (
    <Box flex={4} p={{ xs: 0, md: 2 }}>
      {loading ? (
        <Stack spacing={1}>
          <Skeleton variant="text" height={100} />
          <Skeleton variant="text" height={20} />
          <Skeleton variant="text" height={20} />
          <Skeleton variant="rectangular" height={300} />
        </Stack>
      ) : (
        <>
          <Grid direction={"column"} container spacing={matchDownSM ? 0 : 2} columns={{ xs: 4, sm: 8, md: 12, height: "100vh"}}>
            <Grid sx={{m:2}} columns={{ xs: 4, sm: 8, md: 12}}>
              <TextField sx={{color:"black"}} fullWidth id="outlined-search" placeholder= 'Enter your text...' onChange={(e)=>onSearch(e.target.value)} value={searchValue} label="Search field" type="search" />
            </Grid>
            <Grid direction={"column"} columns={{ xs: 12, sm: 8, md: 6, lg: 4}}>
              { setUIPosts() }
            </Grid>
          </Grid>
        </>
      )}
    </Box>
  );
};

export default Feed;