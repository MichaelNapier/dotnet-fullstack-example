import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import Player from './pages/Player/Player'
import Navbar from './components/Navbar/Navbar'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Authentication from './pages/Authentication/Authentication'
import Database from './pages/Database/Database'
import Functions from './pages/Functions/Functions'
import Hosting from './pages/Hosting/Hosting'
import Storage from './pages/Storage/Storage'
import Games from './pages/Games/Games'
ReactDOM.createRoot(document.getElementById('root')).render(


  <BrowserRouter>
  <Routes>
    <Route path="/" element={<App />}>
      <Route path="authentication" element={<Authentication />} />
      <Route path="database" element={<Database />} />
      <Route path="functions" element={<Functions />} />
      <Route path="players" element={<Player />} />
      <Route path="storage" element={<Storage />} />
      <Route path="games" element={<Games/>} />      
    </Route>
  </Routes>
</BrowserRouter>,
 
)