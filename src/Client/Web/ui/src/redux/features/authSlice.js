import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import jwt from "jwt-decode";
import * as api from "../api";

export const login = createAsyncThunk("auth/login", async ({formValues, navigate, toast}, {rejectWithValue}) =>{
    try {
        const response = await api.signIn(formValues);
        toast.success("Login Successfully");
        setTimeout(()=>{
            navigate("/");
        },3000);
        let {data} = response.data;
        data = JSON.parse(data);
        const user = jwt(data); 
        const responseData = {
            token: data,
            user: {
                email: user.email,
                id: user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
                name: user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
                surname: user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"],
            }
        }
        return responseData;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error))
    }
});

export const register = createAsyncThunk("auth/register", async ({formValues, navigate, toast}, {rejectWithValue}) =>{
    try {
        const response = await api.signUp(formValues);
        toast.success("Register Successfully");
        setTimeout(()=>{
            navigate("/login");
        },3000);
        return response.data;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error))
    }
});

const getErrorMessage = (error) => error.response.data ?? error; 

const authSlice = createSlice({
    name: "auth",
    initialState:{
        user: null,
        error: "",
        loading: false
    },
    extraReducers: {
        [login.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [login.fulfilled]: (state, action) => {
            state.loading = false;
            localStorage.setItem("profile", JSON.stringify({...action.payload}));
            state.user = action.payload;
            state.error = "";
        },
        [login.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
        [register.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [register.fulfilled]: (state, action) => {
            state.loading = false;
            state.user = action.payload;
            state.error = "";
        },
        [register.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        }
    }
});

export default authSlice.reducer;