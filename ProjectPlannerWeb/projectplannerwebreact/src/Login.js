import React, { useState } from 'react';
import './login.css'

function Login() {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const handleLoginChange = (e) => {
    setLogin(e.target.value);
  };
  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };
  return (
    <div className='LoginField'>
      <p>
      <label htmlFor="login">Login:   </label>
      </p>
      <input
        type="text"
        id="login"
        value={login}
        onChange={handleLoginChange}
        placeholder="Enter your login..."
      />
      <p>
        <label htmlFor="password">Password: </label>
      </p>
      <input
        type="password"
        id="password"
        value={password}
        onChange={handlePasswordChange}
        placeholder="Enter your password..."
      />
      <p>
        <button>Login</button>
      </p>
    </div>
  );
}

export default Login; 