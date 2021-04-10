import React, {useState, useEffect} from 'react';

import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import Toast from 'react-bootstrap/Toast'

import SoftwareList from './components/softwareList'

import './App.css';


const App = () => {
  const [softwareList, setSoftwareList] = useState([]);  
  const [version, setVersion] = useState();

  const [toastMessage, setToastMessage] = useState();
  const [toastShow, setToastShow] = useState(false);

  const onVersionChange = (event) => {    
    setVersion(event.target.value);
  }

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (version == null) {
      return;
    }

    const response = await fetch(`http://localhost:7071/api/version/${version}`);
    if(response.status === 200) {
      const json = await response.json();
      if (json.length === 0) {
        // I'm cheating here for some kind of no result message.
        setSoftwareList([{"name":"No Results Found","version":"N/A"}]);
      }
      else {
        setSoftwareList(json)
      }
      
    }
    else {
      setSoftwareList([]);
      setToastMessage("The version entered was not a valid version number.");
      setToastShow(true);
    }
    
  }

  return (
    <div className="App">
      <header className="App-header">
      Imaginary Company Software Version Search
      </header>

      <Form onSubmit={handleSubmit}>
        <Form.Group controlId="formVersion">
          <Form.Label>Please enter a version number</Form.Label>
          <Form.Control type="text" placeholder="Examples: 2 or 2.0.0" onChange={onVersionChange}/>          
        </Form.Group>
        
        <Button variant="primary" type="Submit">
          Submit
        </Button>
      </Form>
      <br/>
      <SoftwareList softwareList={softwareList}></SoftwareList>

      <Toast onClose={() => setToastShow(false)} show={toastShow} delay={3000} autohide
        style={{
          position: 'absolute',
          top: 20,
          right: 20,
        }}
      >
        <Toast.Header>          
          <strong className="mr-auto">Error</strong>
        </Toast.Header>
        <Toast.Body>{toastMessage}</Toast.Body>
      </Toast>
    </div>
    
  );
}

export default App;
