import { basePath, apiVersion } from "./config";
import { Book } from "../types";

export const getBook = (id: number) => {
  return fetchBook(id);
};

const fetchBook = (id: number): Promise<Book> => {
  const url = `${basePath}/${apiVersion}/book/${id}`;
  return fetch(url).then((res) => res.json());
};
