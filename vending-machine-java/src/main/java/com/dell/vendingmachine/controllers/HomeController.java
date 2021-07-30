package com.dell.vendingmachine.controllers;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.Product;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.service.VendingMachineService;
import lombok.val;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/home")
public class HomeController {

    @Autowired
    VendingMachineService vendingMachineService;

    public HomeController(){}

    @GetMapping(value="hello")
    public ResponseEntity<String> hello() {
        return new ResponseEntity<String>("Hello." , HttpStatus.OK);
    }

    @PostMapping(value="/{id}")
    public ResponseEntity<VendingMachine> AddCredit(@PathVariable Long id, @RequestBody VendingCredit credit ) {

        VendingMachine updated = vendingMachineService.AddCredit(id, credit);
        return new ResponseEntity<VendingMachine>( updated, HttpStatus.OK);
    }

    @PostMapping(value="create")
    public ResponseEntity<VendingMachine> Create(@RequestBody VendingMachine vendingMachine ) {

        VendingMachine created = vendingMachineService.Create(vendingMachine);
        return new ResponseEntity<VendingMachine>( created , HttpStatus.OK);
    }

    @GetMapping(value="/{id}")
    public ResponseEntity<VendingMachine> GetProducts(@PathVariable Long id) {

        return new ResponseEntity<VendingMachine>(vendingMachineService.FindById(id), HttpStatus.OK);
    }

    @PostMapping(value="{id}/product/{productId}")
    public ResponseEntity<String> BuyProduct(@PathVariable Long id, @PathVariable Long productId ) {

        return new ResponseEntity<String>( "DoSomething" , HttpStatus.OK);
    }

}
