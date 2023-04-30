import { useId, useState, useEffect } from "react";
import { Pizzeria } from "../models/pizzeria";
import { Pizza } from "../models/pizza"
import PizzaList from "./PizzaList";
import { DropdownButton, Dropdown, Container, Row, Col, Button, InputGroup } from "react-bootstrap";
import { FaPlus } from "react-icons/fa";
import { RiCloseFill } from "react-icons/ri";
import { Input } from "reactstrap";

function PizzeriaDropdown(props) {
  const [selectedPizzeria, setSelectedPizzeria] = useState({id: '', name: ''});
  const [newPizzeria, setNewPizzeria] = useState({name: '', location: ''});
  const [pizzerias, setPizzerias] = useState([]);
  const [showAddPizzeria, setShowAddPizzeria] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("pizzeria/GetPizzerias");
        const data = await response.json();
        setPizzerias(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);
  
  const addNewPizzeria = () => {
    if(showAddPizzeria){
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: newPizzeria.name, location: newPizzeria.location }),
    };
    fetch('pizzeria?' + new URLSearchParams({ name: newPizzeria.name, location: newPizzeria.location }), requestOptions)
        .then(response => response.json());
    }
    else{
      setShowAddPizzeria(true);
    }
  };

  const hideNewPizzeria = () => {
    setShowAddPizzeria(false);
  }

  function handleNewPizzeriaOnChange(key, value) {
    setNewPizzeria({
      ...newPizzeria,
      [key]: value
    });
  }

  return (<>
  <Container>
    <Row className="justify-content-md-center pt-3">
      <Col xs lg="8">
        <InputGroup  className="justify-content-md-center">
          <DropdownButton title={selectedPizzeria.name ? selectedPizzeria.name : "Select an item"}>
            {pizzerias.map((item, index) => (
              <Dropdown.Item key={index} onClick={() => setSelectedPizzeria((e) => ({...e, id: item.id, name:item.name}))}>
                {item.name}
              </Dropdown.Item>
            ))}
          </DropdownButton>
          {
            showAddPizzeria ?
            <>
              <Input value={newPizzeria['name']} onChange={e => handleNewPizzeriaOnChange('name', e.target.value)} placeholder="Enter pizzeria name"></Input>
              <Input value={newPizzeria['location']} onChange={e => handleNewPizzeriaOnChange('location', e.target.value)} placeholder="Enter pizzeria location"></Input>
              <Button variant="danger" onClick={() => {hideNewPizzeria()}}><RiCloseFill icon="fa-light fa-xmark" /></Button>              
            </>
          : null 
          }
          <Button variant="success" onClick={() => {addNewPizzeria()}}><FaPlus icon="fa-light fa-plus" /></Button>
        </InputGroup>
      </Col>
    </Row>
      <PizzaList pizzeriaId={selectedPizzeria.id}></PizzaList>
    </Container>
    </>
  );
}

export default PizzeriaDropdown;
