import {
    Avatar,
    Button,
    ButtonGroup,
    Fab,
    Modal,
    Stack,
    styled,
    TextField,
    Tooltip,
    Typography,
  } from "@mui/material";
  import React, { useState, useEffect } from "react";

  import {
    Add as AddIcon,
    EmojiEmotions,
    Image,
    PersonAdd,
    VideoCameraBack,
  } from "@mui/icons-material";
  import { Box } from "@mui/system";
  import AnimateButton from "./AnimateButton";
  import {useDispatch} from "react-redux";
  import {toast} from "react-toastify";
  import {createPost} from "../redux/features/postSlice";
import JWTHelper from "../utils/jwtHelper";
  const SytledModal = styled(Modal)({
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  });
  
  const UserBox = styled(Box)({
    display: "flex",
    alignItems: "center",
    gap: "10px",
    marginBottom: "20px",
  });
  
  const Add = () => {
    const [open, setOpen] = useState(false);
    const [postValue, setPostValue] = useState("");
    const [error, setError] = useState("");
    const {name, surname} = JWTHelper.getUserDetails().user;
    const dispatch = useDispatch();

    useEffect(() => {
      error && toast.error(error);
    }, [error]);


    const addPost = (event) =>{
      try{
        if(!postValue && postValue === "" && postValue.length <= 2){
          setError("Please don't submit without writed any post value");
          event.preventDefault();
        }else{
          const parameters = {
            postValue,
            setOpen,
            toast
          }
          setError("");
          dispatch(createPost(parameters));
          // setOpen(false);
        }
      }catch(err){
        toast.error(err);
      }
    };

    const onChangePostValue = (event) => {
      if(event.target && event.target.value && event.target.value.length > 0){
        setError("");
      }
      setPostValue(event.target.value);
    }
    return (
      <>
        <Tooltip
          onClick={(e) => setOpen(true)}
          title="Add"
          sx={{
            position: "fixed",
            bottom: 20,
            left: { xs: "calc(50% - 25px)", md: 30 },
          }}
        >
          <Fab color="primary" aria-label="add">
            <AddIcon />
          </Fab>
        </Tooltip>
        <SytledModal
          open={open}
          onClose={(e) => setOpen(false)}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box
            width={400}
            height={330}
            bgcolor={"background.default"}
            color={"text.primary"}
            p={3}
            borderRadius={5}
          >
            <Typography variant="h6" color="gray" textAlign="center">
              Create post
            </Typography>
            <UserBox>
              <Avatar
                src="https://images.pexels.com/photos/846741/pexels-photo-846741.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
                sx={{ width: 30, height: 30 }}
              />
              <Typography fontWeight={500} variant="span">
                {`${name} ${surname}`}
              </Typography>
            </UserBox>
            <TextField
              sx={{ width: "100%" }}
              id="standard-multiline-static"
              multiline
              error={!!error}
              rows={3}
              helperText={error}
              onChange={onChangePostValue}
              placeholder={"What's on your mind?"}
              variant="standard"
            />
            <Stack direction="row" gap={1} mt={2} mb={3}>
              <EmojiEmotions color="primary" />
              <Image color="secondary" />
              <VideoCameraBack color="success" />
              <PersonAdd color="error" />
            </Stack>
            <ButtonGroup
              variant="contained"
              aria-label="outlined primary button group"
              style={
                {float:"right"}
              }
            >
              <AnimateButton>
                <Button
                    disableElevation
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                    color="primary"
                    onClick={addPost}
                >
                    POST
                </Button>
               </AnimateButton>
            </ButtonGroup>
          </Box>
        </SytledModal>
      </>
    );
  };
  
  export default Add;