import React from 'react';
import { render } from 'react-dom';
import { BrowserRouter as Router, Route } from 'react-router-dom';

import Index from './index';
import Detail from './detail';

const App = () => (
    <Router>
        <Route exact path="/AssetView" component={Index} />
        <Route exact path="/asset/:Id" component={Detail} />
    </Router>
);

render(<App />, document.getElementById('app'));