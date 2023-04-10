import { configureStore, ThunkAction, Action, combineReducers } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/dist/query';

import productReducer from './reducer/productReducer';
import categoryReducer from './reducer/categoryReducer';
import authReducer from './reducer/authReducer';
import cartReducer from './reducer/cartReducer';
import userReducer from './reducer/userReducer';
import { authApi } from '../services/authApi';
import storage from 'redux-persist/lib/storage';
import {
  persistStore,
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from 'redux-persist'

const persistConfig = {
  key: 'root',
  storage,
}
const rootReducer = combineReducers({
  cart: cartReducer,
  auth: authReducer
})
const persistedReducer = persistReducer(persistConfig, rootReducer)

export const createStore = () => {
  return configureStore({
    reducer: {
      productReducer,
      categoryReducer,
      persistedReducer,
      userReducer,
      [authApi.reducerPath]: authApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware({
        serializableCheck: {
          ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
        },
      }).concat(authApi.middleware),
  })
}

const store = createStore()
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>
export const persistor = persistStore(store)
setupListeners(store.dispatch)

export { configureStore, store };

