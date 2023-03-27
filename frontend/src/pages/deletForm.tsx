import * as React from 'react';
import { Box, TextField, Button, Typography } from '@mui/material'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import { toast, ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom'

import { logout } from '../redux/reducer/authReducer'
import { fetchAllUser, deleteUser } from '../redux/reducer/userReducer'
import axios from 'axios';
import { User } from '../types/Auth';

const DeleteForm = (props: any) => {
    const dispatch = useAppDispatch()
    const user = useAppSelector(state => state.userReducer)
    const navigate = useNavigate()
    const handleDelete = async() => {
        try {
            await dispatch(deleteUser({ id: props.userId }))
            const newApi = await fetch("https://api.escuelajs.co/api/v1/users")
            const data: any = await newApi.json()
            const isExist = data.filter((currentUser: { id: any; }) => {
                return currentUser.id == props.userId
            })
            if(isExist.length === 0) {
                toast.success("Your account has been deleted!")
                dispatch(logout())
                navigate('/auth')
            }
            else {
                toast.error("Server Error! Try after some time")
            }

        }
        catch(error) {
            return error
        }
    }
    return (
        <Box>
            <Typography>Are you sure you want to delete!</Typography>
            <Button onClick={handleDelete}>Delete</Button>
        </Box>
    )
}
export default DeleteForm
function async(userId: any) {
    throw new Error('Function not implemented.');
}

