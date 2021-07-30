package com.dell.vendingmachine.service;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.repository.VendingMachineRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public interface VendingMachineService {


    public VendingMachine AddCredit(Long id, VendingCredit credit);

    public VendingMachine Create(VendingMachine vendingMachine);

    public  VendingMachine FindById(long id);

}
