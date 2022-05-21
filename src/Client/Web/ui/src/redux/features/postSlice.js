import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import * as api from "../api";


export const getPosts = createAsyncThunk("posts/getPosts", async ({}, {rejectWithValue}) =>{
    try {
        const response = await api.getAllPosts();
        return response.data;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error))
    }
});

export const createPost = createAsyncThunk("posts/createPost", async ({postValue , setOpen, toast}, {rejectWithValue}) =>{
    try{
        const response = await api.addPost(postValue).catch((error)=>{
            throw error;
        })
        setOpen(false);
        toast.success(response.data.message);
        setTimeout(async () => {
            window.location.reload();
        }, 500);
    }catch(error){
        if(error.response.status === 401){
            toast.error("Failed Token error, please try again login");
            return rejectWithValue({Message: error.message});
        }
        setOpen(true);
        return rejectWithValue(getErrorMessage(error));
    }
});

export const deletePost = createAsyncThunk("posts/deletePost", async ({id , setOpenModal, toast}, {rejectWithValue}) =>{
    try{
        const response = await api.deleteByIdPost(id).catch((error)=>{
            throw error;
        })
        // setOpenModal(false);
        toast.success(response.data.message);
        window.location.reload();
    }catch(error){
        if(error.response.status === 401){
            toast.error("Failed Token error, please try again login");
            return rejectWithValue({Message: error.message});
        }
        setOpenModal(true);
        return rejectWithValue(getErrorMessage(error));
    }
});

const getErrorMessage = (error) => error.response.data ?? error; 

const getPostDetails = (postDetails) =>{
    const postData = [];
    postDetails.forEach(postDetail => {
        if(postDetail.posts && postDetail.posts.length === 1){
            postData.push({
                userId: postDetail.id,
                name: postDetail.name,
                surname: postDetail.surname,
                postMessage: postDetail.posts[0].message,
                postId: postDetail.posts[0].id
            });
        }
        if(postDetail.posts && postDetail.posts.length >= 2){
            postDetail.posts.forEach((post)=>{
                postData.push({
                    userId: postDetail.id,
                    name: postDetail.name,
                    surname: postDetail.surname,
                    postMessage: post.message,
                    postId: post.id
                });
            });
        }
    });
    return postData;
}


const postSlice = createSlice({
    name:"posts",
    initialState:{
        list: [],
        loading: false,
        error: "",
    },
    extraReducers: {
        [getPosts.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [getPosts.fulfilled]: (state, action) => {
            state.loading = false;
            state.list = getPostDetails(action.payload.data);
            state.error = "";
        },
        [getPosts.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },

        [createPost.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [createPost.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [createPost.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },

        [deletePost.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [deletePost.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [deletePost.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
    }
});

export default postSlice.reducer;