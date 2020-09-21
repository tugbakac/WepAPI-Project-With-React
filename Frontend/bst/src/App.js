import React from 'react';
import logo from './logo.svg';
import './App.css';
import Button from 'react-bootstrap/Button';
import {Home} from './components/Home';
import {Departments} from './components/Departments';
import {Employees} from './components/Employees';
import {BrowserRouter,Route,Switch} from 'react-router-dom';
import {Navigation} from './components/Navigation';


function App() {
  return (
    <BrowserRouter>
    <h3 className="m-3 d-flex justify-content-center">
      React Js with Bootstrap
    </h3>
    <h5 className="m-3 d-flex justify-content-center">
      Employee Management Portal 
    </h5>
    <Navigation/>
      <Switch>
        <Route path='/' component={Home} exact/>
        <Route path='/department' component={Departments} />
        <Route path='/employee' component={Employees} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
