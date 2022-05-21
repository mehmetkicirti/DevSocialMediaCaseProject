import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import * as api from "../api";


export const getUserById = createAsyncThunk("users/getUserById", async ({id}, {rejectWithValue}) =>{
    try {
        const response = await api.getByIdUser(id);
        return response.data;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error))
    }
});

export const updateUser = createAsyncThunk("users/updateUser", async ({formValue, toast}, {rejectWithValue}) =>{
    try{
        const response = await api.updateUser(formValue).catch((error)=>{
            throw error;
        })
        toast.success(response.data.message);
    }catch(error){
        if(error.response.status === 401){
            toast.error("Failed Token error, please try again login");
            return rejectWithValue({Message: error.message});
        }
        return rejectWithValue(getErrorMessage(error));
    }
});

const getErrorMessage = (error) => error.response.data ?? error; 


const userSlice = createSlice({
    name:"users",
    initialState:{
        appUsers: [],
        appUser: null,
        loading: false,
        error: ""
    },
    extraReducers:{
        [getUserById.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [getUserById.fulfilled]: (state, action) => {
            state.loading = false;
            state.appUser = action.payload.data; 
            state.error = "";
        },
        [getUserById.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
        [updateUser.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [updateUser.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [updateUser.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
    }
});

export default userSlice.reducer;