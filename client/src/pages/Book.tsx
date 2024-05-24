import { Row, Col } from "antd";
import { FC } from "react";
import BooksListWeb from "../components/BooksListWeb/BooksListWeb";

const Book: FC = () => {
  return (
    <Row gutter={24}>
      <Col span={4} />
      <Col span={16}>
        <BooksListWeb />
      </Col>
      <Col span={4} />
    </Row>
  );
};

export default Book;
