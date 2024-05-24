import { useEffect, useState } from "react";
import { getBookDetail } from "../../api/getBookDetail";
import { Book, BookDetail as Detail } from "../../types";
import { useParams, useSearchParams } from "react-router-dom";
import { getBook } from "../../api/getBook";
import { Spin } from "antd";
import Pagination from "../Pagination/Pagination";
import moment from "moment";
import "moment/locale/en-gb";

interface AppState {
  book: Book;
  bookDetail: Detail;
}

export default function BookPageDetail() {
  const [book, setBook] = useState<AppState["book"]>();
  const [bookDetail, setBooksDetail] = useState<AppState["bookDetail"]>();
  const { id } = useParams();
  const [searchParams, setSearchParams] = useSearchParams();
  const [page, setPage] = useState(1);

  useEffect(() => {
    getBook(parseParams(id))
      .then(setBook)
      .catch((err) => {
        console.log(err);
      });

    getBookDetail(parseParams(id), parseParams(searchParams.get("Page")))
      .then(setBooksDetail)
      .catch((err) => {
        console.log(err);
      });

    setPage(parseParams(searchParams.get("Page")));
  }, [id, searchParams]);

  if (!book) {
    return <Spin tip="Loading" style={{ width: "100%", padding: "200px 0" }} />;
  }

  return (
    <>
      <h1 style={{ textAlign: "center" }}>Name: {book?.name}</h1>
      <h3 style={{ textAlign: "center" }}>Author: {book?.author}</h3>
      <h4 style={{ textAlign: "center" }}>
        Published Date: {moment(book?.publishedDate).format("MM-DD-yyyy")}
      </h4>

      <p style={{ margin: "0 60px", textAlign: "justify" }}>
        {bookDetail?.content}
      </p>

      <Pagination dataCount={book?.count} page={page} />
    </>
  );
}

function parseParams(parameter: string | undefined | null) {
  let convertedId: number = 1;
  if (parameter !== undefined && parameter !== null) {
    convertedId = parseInt(parameter);
  }
  return convertedId;
}
