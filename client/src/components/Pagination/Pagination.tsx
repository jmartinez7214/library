import { Pagination as PaginationAntd } from "antd";
import { useLocation, useNavigate } from "react-router-dom";

import "./Pagination.scss";

interface Props {
  dataCount: number;
  page: number;
}

const Pagination = ({ dataCount, page }: Props) => {
  const { pathname } = useLocation();
  const history = useNavigate();

  const onChangePage = (newPage: any) => {
    history(`${pathname}?Page=${newPage}`);
  };

  return (
    <PaginationAntd
      defaultCurrent={page}
      total={dataCount}
      pageSize={1}
      onChange={(newPage) => onChangePage(newPage)}
      className="pagination"
    />
  );
};

export default Pagination;
