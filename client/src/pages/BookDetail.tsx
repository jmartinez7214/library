import { FC } from "react";
import { Row, Col } from "antd";
import BookPageDetail from "../components/BookPageDetail/BookPageDetail";

const BookDetail: FC = () => {
  return (
    <Row gutter={24}>
      <Col span={4} />
      <Col span={16}>
        <BookPageDetail />
      </Col>
      <Col span={4} />
    </Row>
  );
};

export default BookDetail;
