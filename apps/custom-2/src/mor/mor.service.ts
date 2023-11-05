import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { MorServiceBase } from "./base/mor.service.base";

@Injectable()
export class MorService extends MorServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
