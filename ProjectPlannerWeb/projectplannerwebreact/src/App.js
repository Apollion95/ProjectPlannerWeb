import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Note the change from Switch to Routes
import NavBar from './Navbar';
import Login from './Login';
import MainPage from './MainPage';
import './App.css'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Project Planner</h1>
      </header>
      <Router>
        <NavBar />
        <Routes> 
          <Route path="/Login" element={<Login />} />
          <Route path="/MainPage" element={<MainPage />} /> 
        </Routes>
      </Router>
    </div>
  );
}

export default App;
