import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { MorModuleBase } from "./base/mor.module.base";
import { MorService } from "./mor.service";
import { MorController } from "./mor.controller";
import { MorResolver } from "./mor.resolver";

@Module({
  imports: [MorModuleBase, forwardRef(() => AuthModule)],
  controllers: [MorController],
  providers: [MorService, MorResolver],
  exports: [MorService],
})
export class MorModule {}
