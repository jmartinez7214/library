export interface Book {
  id: number;
  name: string;
  author: string;
  publishedDate: datetime;
  count: number;
}

export type BooksResponseFromApi = Array<{
  id: number;
  name: string;
  author: string;
  publishedDate: datetime;
  count: number;
}>;

export interface BookDetail {
  id: number;
  page: number;
  content: string;
  bookId: number;
}

export type BookDetailResponseFromApi = Array<{
  id: number;
  page: number;
  content: string;
  bookId: number;
}>;
