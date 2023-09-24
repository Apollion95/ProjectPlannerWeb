import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css"; 

function NavBar() {
  return (
    <ul className="navbar-menu">
      <li className="ml-auto">
        <Link to="/Login">
          <button>Login</button>
        </Link>
      </li>
      <li className="ml-auto">
        <Link to="/MainPage">
          <button>Main Page</button>
        </Link>
      </li>
      <li className="ml-auto">
        <Link to="/ProjectsPage">
          <button>Projects</button>
        </Link>
      </li>
      <li className="ml-auto">
        <Link to="/AdminPage">
          <button>Admin</button>
        </Link>
      </li>
    </ul>
  );
}

export default NavBar;
