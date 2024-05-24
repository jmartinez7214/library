import { Menu } from "antd";
import { Link } from "react-router-dom";

import "./MenuTop.scss";

export default function MenuTop() {
  return (
    <Menu className="menu-top-web" mode="horizontal">
      <div>
        <Menu.Item key="logo" className="menu-top-web__logo">
          <Link to={"/"}>Library</Link>
        </Menu.Item>
      </div>

      <div className="menu-top-web__right">
        <Menu.Item key="home" className="menu-top-web__item">
          <Link to="/">Home</Link>
        </Menu.Item>
        <Menu.Item key="book" className="menu-top-web__item">
          <Link to="/book">Books</Link>
        </Menu.Item>
      </div>
    </Menu>
  );
}
