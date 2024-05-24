import { basePath, apiVersion } from "./config";
import { Book } from "../types";

export const getAllBooks = (): Promise<Book[]> => {
  const url = `${basePath}/${apiVersion}/book`;
  return fetch(url)
    .then((res) => res.json())
    .then((data) => data)
    .catch((err) => err);
};
