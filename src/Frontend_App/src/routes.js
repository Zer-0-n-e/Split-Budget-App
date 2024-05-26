import React from 'react';
import { BrowserRouter as Router, RouterProvider, Route, Redirect, useLocation, Routes, Navigate} from "react-router-dom";
// import { Switch } from 'react-router';
import Register from './containers/register';
import Login from './containers/auth';


let landingPage=<Register />;

const AppRouter = () => {

    return (
        <Router>
            <Routes>
                <Route path="/register" element={<Register />}/>
                <Route path="/login" element={<Login />} />
                <Route exact path="/" element={landingPage}  />
            </Routes>
        </Router>
);

}

export default AppRouter;