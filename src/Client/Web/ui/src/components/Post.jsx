import { Favorite, FavoriteBorder, MoreVert, Share } from "@mui/icons-material";
import {useState} from "react";
import { useDispatch } from "react-redux";
import {
  Avatar,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Modal,
  styled,
  Box,
  Checkbox,
  ButtonGroup,
  Button,
  IconButton,
  Typography,
} from "@mui/material";
import AnimateButton from "./AnimateButton";
import CloseIcon from '@mui/icons-material/Close';
import { deletePost } from "../redux/features/postSlice";
import {toast} from "react-toastify";
const Post = ({postItem}) => {
  const dispatch = useDispatch();
  const [open, setOpen] = useState(false);
  const [openModal, setOpenModal] = useState(false);
  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    border: '2px solid #000',
    borderRadius: "5px",
    p: 4,
  };
  
  const SytledModal = styled(Modal)({
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  });

  const onReject = (event) => {
    setOpenModal(false);
  }
  const onApprove = () => {
    if(postItem.postId != null){
      dispatch(deletePost({id:postItem.postId, setOpenModal, toast}))
    }
  };

  return (
    postItem && postItem != null ? 
    <>
      <Card sx={{ margin: 5 }}>
        <CardHeader
          avatar={
            <Avatar sx={{ bgcolor: "red" }} aria-label="recipe">
              {`${postItem.name.toUpperCase().at(0)}`}
            </Avatar>
          }
          action={
            <IconButton onClick={(e) => setOpenModal(true)} aria-label="settings">
              <CloseIcon />
            </IconButton>
          }
          title={`${postItem.name} ${postItem.surname}`}
        />
        <CardContent>
          <Typography variant="body2" color="text.secondary">
            {postItem.postMessage}
          </Typography>
        </CardContent>
        <CardActions disableSpacing>
          <IconButton aria-label="add to favorites">
            <Checkbox
              icon={<FavoriteBorder />}
              checkedIcon={<Favorite sx={{ color: "red" }} />}
            />
          </IconButton>
          <IconButton aria-label="share">
            <Share />
          </IconButton>
        </CardActions>
      </Card>
      <SytledModal
          open={openModal}
          onClose={(e) => setOpenModal(false)}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
        >
          <Box
            width={400}
            height={110}
            bgcolor={"background.default"}
            color={"text.primary"}
            p={3}
            m={2}
            borderRadius={5}
          >
            <Typography variant="h6" color="gray" textAlign="center">
              Do you want to remove the post?
            </Typography>
            <ButtonGroup
              variant="contained"
              aria-label="outlined primary button group"
              style={
                {display: "flex",
                  justifyContent:"space-evenly",
                  border:"none",
                  outline:"none",
                  boxShadow:"none"
                }
              }
            >
              <AnimateButton>
                <Button
                    disableElevation
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                    color="error"
                    onClick={onReject}
                >
                    No
                </Button>
               </AnimateButton>
              <AnimateButton>
                <Button
                    disableElevation
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                    color="success"
                    onClick={onApprove}
                >
                    Yes I want
                </Button>
               </AnimateButton>
            </ButtonGroup>
          </Box>
        </SytledModal>
    </> : <></>
  );
};

export default Post;