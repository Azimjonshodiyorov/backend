import * as React from 'react'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import { useNavigate, Link } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { toast } from 'react-toastify'

import AppBar from '@mui/material/AppBar'
import Box from '@mui/material/Box'
import Toolbar from '@mui/material/Toolbar'
import IconButton from '@mui/material/IconButton'
import Typography from '@mui/material/Typography'
import Menu from '@mui/material/Menu'
import MenuIcon from '@mui/icons-material/Menu'
import Container from '@mui/material/Container'
import Avatar from '@mui/material/Avatar'
import Button from '@mui/material/Button'
import Tooltip from '@mui/material/Tooltip'
import MenuItem from '@mui/material/MenuItem'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart'
import { styled } from '@mui/material/styles'
import CssBaseline from '@mui/material/CssBaseline'
import Badge, { BadgeProps } from '@mui/material/Badge'



import { logout, selectAuth } from '../redux/reducer/authReducer'
import { fetchAllUser } from '../redux/reducer/userReducer'

const pages = ['Products', 'Pricing', 'Blog']
const StyledBadge = styled(Badge)<BadgeProps>(({ theme }) => ({
  '& .MuiBadge-badge': {
    right: -3,
    top: 13,
    border: `2px solid ${theme.palette.background.paper}`,
    padding: '0 4px',
    background: "red"
  },
}))

const Header = (props: any) => {
  const navigate = useNavigate()
  const dispatch = useAppDispatch()
  const { token } = useAppSelector(selectAuth)
  const cart = useAppSelector(state => state.persistedReducer.cart.cartItems)
  const [anchorElNav, setAnchorElNav] = useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);
  const users = useAppSelector(state => state.userReducer.filter((item: { email: any }) => {
    return item.email === props.user
  }))
  useEffect(() => {
    dispatch(fetchAllUser())
  }, [])
  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  }
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  }
  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  }
  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  }
  const getTotalQuantity = () => {
    let total = 0
    cart.forEach((item: { quantity: number, }) => {
      const { quantity } = item;
      total += quantity
    })
    return total
  }
  const handleClick = () => {
    dispatch(logout())
    toast.success("User logout successfully")
    navigate('/auth')
  }

  return (
    <AppBar position="static">
      <CssBaseline />
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              mr: 2,
              display: { xs: 'none', md: 'flex' },
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Lu-Lu
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'left',
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: 'block', md: 'none' },
              }}
            >
              {pages.map((page) => (
                <MenuItem key={page} onClick={handleCloseNavMenu}>
                  <Typography textAlign="center">{page}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
          <AddShoppingCartIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href="/home"
            sx={{
              mr: 2,
              display: { xs: 'flex', md: 'none' },
              flexGrow: 1,
              fontFamily: 'monospace',
              fontWeight: 700,
              letterSpacing: '.3rem',
              color: 'inherit',
              textDecoration: 'none',
            }}
          >
            Lu-Lu
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
            {/* {pages.map((page) => ( */}
            <Button
              onClick={handleCloseNavMenu}
              sx={{ my: 2, color: 'white', display: 'block' }}
            >
              <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/'}>Home</Link>
              <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/home'}>Products</Link>
            </Button>
            {/* ))} */}
          </Box>
          <Box sx={{  display: 'grid', gap: 3, gridTemplateColumns: 'repeat(2, 1fr)' }}>
            {!token? (''):(
              <IconButton sx = {{ mr: 2 }} aria-label="cart" onClick={() => navigate('/cart')}>
              <StyledBadge badgeContent={getTotalQuantity() || 0} color="secondary">
                <AddShoppingCartIcon />
              </StyledBadge>
            </IconButton>
            )}  
            <Avatar sx = {{ width: 70 }}>
            {!token ? (
              <Link style={{ textDecoration: "none", color: "white", fontWeight: "bold", margin: 10 }} to={'/auth'}>Login</Link>
            ) : (
              <>
                <Tooltip title="Open settings">
                  <IconButton onClick={handleOpenUserMenu} sx={{ mr: 1, pb: 2 }}>
                    {users.map(user => (
                      <Typography sx={{ display: 'grid', gridTemplateColumns: 'repeat(2, 1fr)', color: 'white' }}>
                        <Avatar alt="Remy Sharp" src={user.avatar} />
                        <Typography variant="subtitle1" sx={{ fontWeight: 'bold' }}>{user.name}</Typography>
                      </Typography>
                    ))}
                  </IconButton>
                </Tooltip>
                <Menu
                  sx={{ mt: '45px' }}
                  id="menu-appbar"
                  anchorEl={anchorElUser}
                  anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                  }}
                  keepMounted
                  transformOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                  }}
                  open={Boolean(anchorElUser)}
                  onClose={handleCloseUserMenu}
                >
                  <MenuItem onClick={handleCloseUserMenu}>
                    <Typography textAlign="center">
                      <Button variant="text" sx={{ m: 1 }}>
                        <Link style={{ textDecoration: "none", color: "#2979c4", fontWeight: "normal" }} to={'/profile'}>Profile</Link></Button><br />
                      <Button type="submit" variant="text" sx={{ m: 1 }} onClick={() => handleClick()}>Logout</Button>
                    </Typography>
                  </MenuItem>
                </Menu>
              </>
            )}
            </Avatar>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  )
}
export default Header;