import { Button } from "antd";
import { FC } from "react";
import { Link } from "react-router-dom";

const Home: FC = () => {
  return (
    <div style={{ textAlign: "center" }}>
      <h1>Welcome to the GBH Library</h1>

      <h3>Here you can find digital books for free.</h3>

      <Link to="/book">
        <Button type="primary">Go To Books Page</Button>
      </Link>
    </div>
  );
};

export default Home;
