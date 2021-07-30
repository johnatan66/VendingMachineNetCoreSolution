package com.dell.vendingmachine.service.impl;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.Product;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.repository.ProductRepository;
import com.dell.vendingmachine.repository.VendingMachineRepository;
import com.dell.vendingmachine.service.ProductService;
import com.dell.vendingmachine.service.VendingMachineService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class ProductImpl implements ProductService {

    @Autowired
    ProductRepository productRepository;


    @Transactional
    public Product Create(Product product){

        return productRepository.save(product);

    }
}
