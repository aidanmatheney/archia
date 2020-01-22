import React, { FunctionComponent } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import styled from 'styled-components/macro';

import { RestfulProvider } from 'restful-react';

const Container = styled.div`
  height: 100vh;
  display: flex;
  flex-direction: column;
`;

const Header = styled.div`
  height: 10rem;
  background: green;
`;

const Body = styled.div`
  flex-grow: 1;

  display: flex;
  flex-direction: row;
`;

const Sidebar = styled.div`
  width: 20rem;
  background: red;
`;

const Content = styled.div`
  flex-grow: 1;
`;



const App: FunctionComponent = () => {
  return (
    <Container>
      <Header>

      </Header>
      <Body>
        <Sidebar>

        </Sidebar>
        <Content>

        </Content>
      </Body>
    </Container>
  );
};

const ContextfulApp: FunctionComponent = props => (
  <RestfulProvider base="https://localhost:5001">
    <App {...props} />
  </RestfulProvider>
);

export default ContextfulApp;
