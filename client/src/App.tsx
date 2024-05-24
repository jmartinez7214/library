import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Home from "./pages/Home";
import Book from "./pages/Book";
import Error from "./pages/Error";
import MenuTop from "./components/MenuTop/MenuTop";
import BookDetail from "./pages/BookDetail";

import "./App.css";

function App() {
  return (
    <Router>
      <MenuTop />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/book" element={<Book />} />
        <Route path="/book/:id" element={<BookDetail />} />
        <Route path="*" element={<Error />} />
      </Routes>
    </Router>
  );
}

export default App;
