import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'

import { Box, Grid, Card, Typography, Button, Paper, styled, TextField, MenuItem } from '@mui/material'

import CartItem from './CartItem'
import Header from "./Header"

import { Product } from '../types/Product'


const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));
export const Total = () => {
  const cart = useAppSelector((state) => state.persistedReducer.cart.cartItems)
  const getTotal = () => {
    let totalQuantity = 0
    let totalPrice = 0
    cart.forEach(item => {
      totalQuantity += item['quantity']
      totalPrice += item['price'] * item['quantity']
    })
    return { totalPrice, totalQuantity }
  }
  return (
    <Box>
      <Typography>ORDER SUMMARY</Typography>
      <Box>
        <Typography className="total__p">
          total ({getTotal().totalQuantity} items)
          : <strong>${getTotal().totalPrice}</strong>
        </Typography>
      </Box>
    </Box>
  )
}

const Cart = () => {
  const cart = useAppSelector((state) => state.persistedReducer.cart.cartItems)
  
  return (
    <>
      <Header />
      <Box sx={{ display: 'grid', gap: 3, gridTemplateColumns: 'repeat(2, 1fr)' }}>
        <Box>
          {(cart.length) === 0 ? (<Typography sx={{ m: 4, fontSize: 25 }}>Your shopping Cart is empty!</Typography>) :
            (<Box>
              <Typography sx={{ m: 4, fontSize: 25 }}>Your Shopping Cart</Typography>
              {cart?.map((item: any) => (
                <CartItem
                  key={item.id}
                  id={item.id}
                  title={item.title}
                  image={item.images[0]}
                  price={item.price}
                  quantity={item.quantity}
                />
              ))}
            </Box>)}
        </Box>
        <Box sx={{ mt: 13 }} >
          <Item>
            <Total />
          </Item>
          <Item>
            <Button variant='contained' color='warning'>Checkout</Button>
          </Item>
        </Box>
      </Box></>
  )
}
export default Cart