import { PropsWithChildren } from "react";
import { Button, Sidebar } from "semantic-ui-react";


const Layout = (props: PropsWithChildren) => {
  return (
    <div>
      {props.children}
    </div>
  )
}

export default Layout;