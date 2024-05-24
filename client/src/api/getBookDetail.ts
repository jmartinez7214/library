import { basePath, apiVersion } from "./config";
import { BookDetail } from "../types";

export const getBookDetail = (id: number | undefined = 1, page: number = 1) => {
  return fetchBookDetail(id, page);
};

const fetchBookDetail = (id: number, page: number): Promise<BookDetail> => {
  const url = `${basePath}/${apiVersion}/book/detail/${id}?Page=${page}`;
  return fetch(url).then((res) => res.json());
};
