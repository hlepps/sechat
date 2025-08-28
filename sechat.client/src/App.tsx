import { useEffect, useState } from 'react';
import './App.css';
import Home from "./pages/Home.tsx"
import Login from "./pages/Login.tsx"
import Register from "./pages/Register.tsx"
import { BrowserRouter, Route, Routes } from 'react-router-dom';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login/> }/>
                <Route path="/register" element={<Register/> }/>
                <Route path="/" element={<Home/> }/>
            </Routes>
        </BrowserRouter>
    );

}

export default App;