import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Autorisation } from "./components/Autorisation";
import { GPT } from "./components/GPT";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/autorisation',
    element: <Autorisation />
  },
  {
    path: '/chat',
    element: <GPT />
  }
];

export default AppRoutes;
