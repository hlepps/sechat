import LogoutLink from "../components/LogoutLink.tsx";
import AuthorizeView, { AuthorizedUser } from "../components/AuthorizeView.tsx";
import Messenger from "../components/messenger.tsx";

function Home() {
    return (
        <AuthorizeView>
            <span><LogoutLink>Logout <AuthorizedUser value="name" /></LogoutLink></span>
            <Messenger sender={0} receiver={0}></Messenger>
        </AuthorizeView>
  );
}

export default Home;