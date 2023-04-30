import { useState, useEffect } from "react";
import {
  Button,
  Row,
  Col,
  Container,
  ListGroup,
  ListGroupItem,
  InputGroup,
} from "react-bootstrap";
import { FaPlus, FaMinus } from "react-icons/fa";
import { Input } from "reactstrap";

function PizzaList(props) {
  const [counter, setCounter] = useState({ index: 0, count: 0 });
  const [pizzas, setPizzas] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      if(props.pizzeriaId == "")
        return;
        
      try {
        const response = await fetch('menu/getmenu?'+ new URLSearchParams({ id: props.pizzeriaId }))
        const data = await response.json();
        setPizzas(data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [props.pizzeriaId]);

  function incrementCounter(){
    setCounter(c => c + 1);
  }

  function decrementCounter(){
    setCounter(c => c - 1);
  }

  return (
    <>
      <Container fluid="md" className="pt-3">
        <ListGroup variant="flush">
        {pizzas.map((pizza, index) => (
            <ListGroup.Item>
              <Row className="justify-content-md-center">
                  <Col xs lg="5">
                    {pizza.name}
                  </Col>
                  <Col xs="2">
                    <InputGroup className="w-75">
                      <Button onClick={decrementCounter}><FaMinus icon="fa-light fa-minus" /></Button>
                      <Input style={{ textAlign: 'center' }} value={counter.count}></Input>
                      <Button onClick={incrementCounter}><FaPlus icon="fa-light fa-plus" /></Button>
                    </InputGroup>
                  </Col>
              </Row>
            </ListGroup.Item>
        ))}
        </ListGroup>
      </Container>
    </>
  );
}

export default PizzaList;
