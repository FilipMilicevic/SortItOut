import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import Utils from "./Utils.js";
import "./Navbar.css";

const Navbar = () => {
  const [menuToggle, setMenuToggle] = useState(true);
  const [subLinkToggle, setSubLinkToggle] = useState(false);

  function menuHandler() {
    setMenuToggle((prevState) => !prevState);
  }
  function subLinkHandler() {
    setSubLinkToggle((prevState) => !prevState);
  }
  return (
    <>
      <div
        className="cus-nav"
        style={menuToggle ? { width: "" } : { width: "220px" }}>
        <ul>
          {Utils.sidebar.map((val) => (
            <li
              key={val.id}
              className="cus-nav-list"
              onClick={val.seeMore && subLinkHandler}>
              <NavLink to={val.url} exact activeClassName="active-tab">
                <span className="nav-list-list">{val.name}</span>
              </NavLink>
              {val.seeMore &&
                val.seeMore.map(
                  (element) =>
                    subLinkToggle && <li key={element.id}>{element.title}</li>
                )}
            </li>
          ))}
        </ul>
      </div>
    </>
  );
};

export default Navbar;
