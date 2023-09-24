import React from "react";
import { Link } from "react-router-dom";


function NavBar() {
    return (
        < ul ClassName='navbar-menu' >
            <li><Link to="/Login">
                <button>Login</button>
            </Link></li>
            <li><Link to="/MainPage">
                <button>MainPage</button>
            </Link></li>
        </ul >
    )
}
export default NavBar;