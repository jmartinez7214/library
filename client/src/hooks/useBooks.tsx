import { useEffect, useState } from "react";
import { Book } from "../types";
import { notification } from "antd";
import { getAllBooks } from "../api/getAllBooks";

const useBooks = () => {
  const [books, setBooks] = useState<Book[]>([]);

  useEffect(() => {
    getAllBooks()
      .then(setBooks)
      .catch(() => {
        notification["error"]({
          message: "Server error, try later.",
        });
      });
  }, []);

  return {
    books,
  };
};

export default useBooks;
