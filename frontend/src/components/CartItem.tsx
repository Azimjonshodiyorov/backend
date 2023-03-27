import { useAppDispatch } from '../hooks/reduxHook'
import { Box, Typography, Button, Paper, styled, TextField } from '@mui/material'
import { incrementQuantity, decrementQuantity, removeItem } from '../redux/reducer/cartReducer'

const CartItem = (props: { id: number, title: string, image: string, price: number, quantity: number }) => {
  const dispatch = useAppDispatch()
  const { id, title, price, image, quantity } = props;
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }))

  return (
    <Box>
      <Item>
        <Box sx={{ display: 'grid', gap: 3, gridTemplateColumns: 'repeat(4, 1fr)' }}>
          <Box>
            <Typography className="cartItem__title">{title}</Typography>
            <Box sx={{ width: "100%" }} component='img' src={image} id="product_img"></Box>
          </Box>
          <Typography sx={{ mt: 5 }} className="cartItem__price">
            <strong>{price}</strong>
            <strong>€</strong>
          </Typography>
          <Box>
            <Button onClick={() => dispatch(incrementQuantity(id))}>+</Button>
            <Typography>{quantity}</Typography>
            <Button onClick={() => dispatch(decrementQuantity(id))}>-</Button>
          </Box>
          <Button sx={{ height: "40%", mt: 3 }}
            className='cartItem__removeButton'
            onClick={() => dispatch(removeItem(id))}>
            Remove
          </Button>
        </Box>
      </Item>
    </Box>
  )
}

export default CartItem