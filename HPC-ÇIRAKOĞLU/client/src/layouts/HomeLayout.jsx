import React, { useState, useEffect } from "react";
import { Outlet } from "react-router-dom";
import Logo from "../images/logo.png";

export default function HomeLayout() {
  return (
    <div>
      <div
        className="fixed-top"
        style={{
          backgroundColor: "#0d2956",
          paddingTop: "15px",
          paddingBottom: "15px",
          textAlign: "center",
        }}
      >
        <img src={Logo} style={{ height: "50px", width: "200px" }} alt="" />
      </div>
      <div className="container">
        <Outlet />
      </div>
    </div>
  );
}
