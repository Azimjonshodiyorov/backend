import { useAppSelector } from '../hooks/reduxHook'
import { selectAuth } from '../redux/reducer/authReducer'

import LoadingtoRedirect from './LoadingtoRedirect'
const PrivateRoute = ({children}:{children:JSX.Element|JSX.Element[]}) => {
    const {token} = useAppSelector(selectAuth)
  return (
  <> {
    token ? [children] : <LoadingtoRedirect />
  } 
  </>
  )
}
export default PrivateRoute