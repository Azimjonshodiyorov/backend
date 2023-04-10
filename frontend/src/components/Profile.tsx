import { JSXElementConstructor, Key, ReactElement, ReactFragment, ReactPortal, useEffect, useState } from 'react'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'

import { Box, Typography, Button, Paper, styled, Modal } from '@mui/material'

import ProfileForm from '../pages/editProfileForm'
import DeleteForm from '../pages/deletForm'
import Header from "./Header"

import { fetchAllUser } from '../redux/reducer/userReducer'
import { User } from '../types/Auth'

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
}
const Profile = (props: User) => {
    const dispatch = useAppDispatch()
    const users = useAppSelector(state => state.userReducer.filter((item: { email: string }) => {
        return item.email === props.userDetail.email
    }))
    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
    }))
    useEffect(() => {
        dispatch(fetchAllUser())
    }, [])
    useEffect(() => {
        const fetchData = async () => {
            try {
                const users = await fetch(`https://api.escuelajs.co/api/v1/users`)
                const data = await users.json()
            } catch (error) {
                console.log("error", error)
            }
        }
        fetchData();
    }, []);
    const [openEdit, setEditOpen] = useState(false);
    const [openDelete, setDeleteOpen] = useState(false);
    const handleEditOpen = () => setEditOpen(true)
    const handleEditClose = () => setEditOpen(false)
    const handleDeleteOpen = () => setDeleteOpen(true)
    const handleDeleteClose = () => setDeleteOpen(false)

    return (
        <>
            <Header />
            <Box sx={{ color: 'black' }} >
                {users.map(user => (
                    <Item>
                        <Box sx={{ borderRadius: "100%", width: "20%", height: "20%" }} component='img' src={user.avatar} id="product_img"></Box>
                        <Typography variant="subtitle1" sx={{ fontWeight: 'bold' }}>{user.name}</Typography>
                    </Item>
                ))}
            </Box>
            <Box sx={{ display: 'grid', width: "50%", height: "70%", mt: "4rem", ml: '20rem', alignItems: 'center' }}>
                {users.map((user: { email: string | number | boolean | ReactElement<any, string | JSXElementConstructor<any>> | ReactFragment | null | undefined; id: Key | null | undefined; name: string | number | boolean | ReactElement<any, string | JSXElementConstructor<any>> | ReactFragment | ReactPortal | null | undefined; password: string | number | boolean | ReactElement<any, string | JSXElementConstructor<any>> | ReactFragment | ReactPortal | null | undefined; role: string | number | boolean | ReactElement<any, string | JSXElementConstructor<any>> | ReactFragment | ReactPortal | null | undefined }) => (
                    <Box>
                        {(user.email !== "admin@mail.com") ? (
                            <Item key={user.id} >
                                <Typography variant="subtitle1" sx={{ fontWeight: 'bold' }}>Name: {user.name}</Typography>
                                <Typography variant="subtitle1" sx={{ fontWeight: 'bold' }}>Email: {user.email}</Typography>
                                <Typography variant='subtitle1' sx={{ fontWeight: 'bold' }}>Password: {user.password}</Typography>
                                <Typography variant='subtitle1' sx={{ fontWeight: 'bold' }}>Role: {user.role}</Typography>
                                <Button onClick={handleEditOpen}>Edit Profile</Button>
                                <Modal
                                    open={openEdit}
                                    onClose={handleEditClose}
                                    aria-labelledby="modal-modal-title"
                                    aria-describedby="modal-modal-description"
                                >
                                    <Box sx={style}>
                                        <ProfileForm userId={user.id} />
                                    </Box>
                                </Modal>
                                <Button onClick={handleDeleteOpen}>Delete Account</Button>
                                <Modal
                                    open={openDelete}
                                    onClose={handleDeleteClose}
                                    aria-labelledby="modal-modal-title"
                                    aria-describedby="modal-modal-description"
                                >
                                    <Box sx={style}>
                                        <DeleteForm userId={user.id} />
                                    </Box>
                                </Modal>
                            </Item>
                        ) : (
                            <Item>
                                <Typography>You are an admin!</Typography>
                            </Item>
                        )}

                    </Box>
                ))}
            </Box>
        </>
    )
}

export default Profile