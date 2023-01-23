import React, { useState } from "react";
import { BrowserRouter, Route, Routes, useNavigate } from "react-router-dom";
import Dashboard from "./Dashboard.js";
import Lager from "./Lager.js"
import Navbar from "./Navbar.js"
import "./styles.css";

function App() {
  return (
    <BrowserRouter>
      <Root />
    </BrowserRouter>
  );
}

function Root() {
  // React States
  const [errorMessages, setErrorMessages] = useState({});
  const [isSubmitted, setIsSubmitted] = useState(false);

  // User Login info
  const database = [
    {
      username: "user1",
      password: "pass1",
    },
    {
      username: "user2",
      password: "pass2",
    },
  ];

  const navigate = useNavigate();

  const errors = {
    uname: "invalid username",
    pass: "invalid password",
  };

  const handleSubmit = (event) => {
    //Prevent page reload
    event.preventDefault();

    var { uname, pass } = document.forms[0];

    // Find user login info
    const userData = database.find((user) => user.username === uname.value);

    // Compare user info
    if (userData) {
      if (userData.password !== pass.value) {
        // Invalid password
        setErrorMessages({ name: "pass", message: errors.pass });
      } else {
        setIsSubmitted(true);
        navigate("/dashboard");
      }
    } else {
      // Username not found
      setErrorMessages({ name: "uname", message: errors.uname });
    }
  };

  // Generate JSX code for error message
  const renderErrorMessage = (name) =>
    name === errorMessages.name && (
      <div className="error">{errorMessages.message}</div>
    );

  // JSX code for login form
  const renderForm = (
    <div className="login-form">
      <form onSubmit={handleSubmit}>
        <div className="input-container">
          <label>Username </label>
          <input type="text" name="uname" required />
          {renderErrorMessage("uname")}
        </div>
        <div className="input-container">
          <label>Password </label>
          <input type="password" name="pass" required />
          {renderErrorMessage("pass")}
        </div>
        <div className="button-container">
          <input type="submit" />
        </div>
      </form>
    </div>
  );

  return (
    <div className="app">
        <div className="title"></div>
        {isSubmitted ? (
          <div className="wrapper">
            <div className="navbar">
              <Navbar />
            </div>
            <div className="content">
              <Routes>
                <Route path="/" element={<Lager />} />
                <Route path="/dashboard" element={<Dashboard />} />
              </Routes>
            </div>
          </div>
        ) : (
          renderForm
        )}
      </div>
  );
}
export default App;
