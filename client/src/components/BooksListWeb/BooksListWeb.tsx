import { Spin, List, Button } from "antd";
import { Link } from "react-router-dom";
import { Book } from "../../types";
import moment from "moment";
import "moment/locale/en-gb";

import "./BooksListWeb.scss";
import useBooks from "../../hooks/useBooks";

const BooksListWeb = () => {
  const { books } = useBooks();

  if (!books) {
    return (
      <Spin tip="Loading..." style={{ width: "100%", padding: "200px 0" }} />
    );
  }

  return (
    <>
      <div className="books-list-web">
        <h1>Books</h1>
        <List
          dataSource={books}
          renderItem={(book) => <BookPost book={book} />}
        />
      </div>
    </>
  );
};

interface BookPostInterface {
  book: Book;
}

const BookPost = ({ book }: BookPostInterface) => {
  const date = moment(book.publishedDate).format("MM-DD-yyyy");

  return (
    <>
      <List.Item
        actions={[
          <Link to={`/book/${book.id}?Page=1`} target="_blank">
            <Button type="primary">
              <span>Read Book</span>
            </Button>
          </Link>,
        ]}
      >
        <List.Item.Meta
          title={`Name: ${book.name} | Author: ${book.author}`}
          description={`Published Date: ${date}`}
        />
      </List.Item>
      <hr />
    </>
  );
};

export default BooksListWeb;
